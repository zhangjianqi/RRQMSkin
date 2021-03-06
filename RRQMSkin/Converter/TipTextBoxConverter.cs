﻿using System;
using System.ComponentModel;
using System.Globalization;
using System.Windows.Controls;
using System.Windows.Media;

namespace RRQMSkin
{
    /// <summary>
    /// 文本转化器
    /// </summary>
    public class TipTextBoxConverter : TypeConverter
    {
        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="sourceType"></param>
        /// <returns></returns>
        //返回一个值，该值指示类型转换器能否将指定类型的对象转换为此转换器的类型
        public override bool CanConvertFrom(ITypeDescriptorContext context, Type sourceType)
        {
            if (sourceType == typeof(string))
            {
                return true;
            }
            return base.CanConvertFrom(context, sourceType);
        }

        /// <summary>
        ///
        /// </summary>
        /// <param name="context"></param>
        /// <param name="culture"></param>
        /// <param name="value"></param>
        /// <returns></returns>
        //从指定值转换为此转换器的预期转换类型。
        public override object ConvertFrom(ITypeDescriptorContext context, CultureInfo culture, object value)
        {
            if (value == null)
            {
                return new TextBlock();
            }
            if (value is string)
            {
                string s = (string)value;

                TextBlock textBlock = new TextBlock();
                textBlock.VerticalAlignment = System.Windows.VerticalAlignment.Center;
                textBlock.HorizontalAlignment = System.Windows.HorizontalAlignment.Left;
                textBlock.Foreground = new SolidColorBrush((Color)ColorConverter.ConvertFromString("#E8E8EC"));
                textBlock.Text = s;

                return textBlock;
            }

            return base.ConvertFrom(context, culture, value);
        }
    }
}