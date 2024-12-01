using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Globalization;
using System.Linq;
using System.Linq.Expressions;
using System.Reflection;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;

namespace Services
{
    public class FilterBuilder<T> where T : class
    {
        private Stack<string> _filterStack=new Stack<string>();

        private readonly string[] _filters;
        private readonly ParameterExpression _parameter;
        private readonly TextInfo _textInfo= CultureInfo.CurrentCulture.TextInfo;


        public FilterBuilder(string[] filters)
        {
            _filters = filters;
            _parameter= Expression.Parameter(typeof(T), "x"); //Input parameter x=>
            
        }
        public Expression<Func<T,bool>> Build()
        {
            bool isGroupingOperator = false;

           

            foreach(var filter in _filters)
            {
                _filterStack.Push(filter);
            }           
            var _accExpression=GenerateExpression(_filterStack.Pop());
            

            while(_filterStack.Count > 0) 
            {
                _accExpression=GroupOperation(_accExpression,_filterStack.Pop(),
                    GenerateExpression(_filterStack.Pop()));         

            }

            return Expression.Lambda<Func<T, bool>>(_accExpression, _parameter);

        }

        private BinaryExpression GroupOperation(BinaryExpression leftExpression,
           string groupOperator,BinaryExpression rightExpression)
        {
            return groupOperator switch
            {
                "and" => Expression.And(leftExpression, rightExpression),
                "or" => Expression.Or(leftExpression, rightExpression),
                _ => throw new NotImplementedException()
            };

        }

        private BinaryExpression GenerateExpression(string expression)
        {
            string[] operation = expression.Split(" ");
            if (operation.Length != 3)
                throw new FormatException("Expression not in proper format");
            try
            {
                PropertyInfo propertyInfo = typeof(T).GetProperty(_textInfo.ToTitleCase(operation[0]));
                if (propertyInfo == null)
                {
                    throw new ArgumentException($"Property '{operation[1]}' not found on type {typeof(T).Name}");
                }
                //so that left and right are of same type
                var rightExpression = Type.GetTypeCode(propertyInfo.PropertyType) switch
                {
                    TypeCode.Int32 => Expression.Convert(Expression.Constant(int.Parse(operation[2])), propertyInfo.PropertyType),
                    _ => Expression.Convert(Expression.Constant(operation[2]), propertyInfo.PropertyType)
                };
                MemberExpression leftExpression = Expression.Property(_parameter, propertyInfo);//x=>x.property

                var relationalExpression = operation[1] switch
                {
                    "eq" => Expression.Equal(leftExpression, rightExpression),
                    "lt" => Expression.LessThan(leftExpression, rightExpression),
                    "gt" => Expression.GreaterThan(leftExpression, rightExpression),
                    _ => throw new NotImplementedException()

                };

                return relationalExpression;


            }
            catch (Exception ex)
            {
                throw new FormatException(ex.Message, ex);
            }
        }
    }
}
