// The MIT License (MIT)
// Permission is hereby granted, free of charge, to any person obtaining a copy of this software and associated documentation files (the "Software"), to deal in the Software without restriction, including without limitation the rights to use, copy, modify, merge, publish, distribute, sublicense, and/or sell copies of the Software, and to permit persons to whom the Software is furnished to do so, subject to the following conditions:
// The above copyright notice and this permission notice shall be included in all copies or substantial portions of the Software.
// THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER DEALINGS IN THE SOFTWARE.
// <copyright file="MVVMCommand.cs" company="Petar Shomov">Copyright (c) 2015 Petar Shomov</copyright>

using System;
using System.ComponentModel;
using System.Linq.Expressions;
using System.Reflection;
using Xamarin.Forms;

namespace Core
{
    public class MVVMCommand : Command
    {
        public MVVMCommand (Action<object> action, Expression<Func<object, bool>> propExpression) : base (action, propExpression.Compile ())
        {
            var member = propExpression.Body as MemberExpression;
            var expression = member.Expression as ConstantExpression;

            if (member == null)
            {
                throw new ArgumentException (
                    string.Format (
                        "Expression '{0}' should be a property.",
                        propExpression.ToString ()));
            }

            if (expression == null)
            {
                throw new ArgumentException (
                    string.Format (
                        "Expression '{0}' should be a constant expression",
                        propExpression.ToString ()));
            }

            var viewModel = (INotifyPropertyChanged)expression.Value;
            var propInfo = member.Member as PropertyInfo;
            if (propInfo == null)
            {
                throw new ArgumentException (
                    string.Format (
                        "Expression '{0}' refers to a field, not a property.",
                        propExpression.ToString ()));
            }

            var propertyName = propInfo.Name;
            viewModel.PropertyChanged += (sender, e) => {
                if (e.PropertyName == propertyName)
                {
                    this.ChangeCanExecute ();
                }
            };
        }
    }
}