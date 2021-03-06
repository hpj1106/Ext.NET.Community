/********
 * This file is part of Ext.NET.
 *     
 * Ext.NET is free software: you can redistribute it and/or modify
 * it under the terms of the GNU AFFERO GENERAL PUBLIC LICENSE as 
 * published by the Free Software Foundation, either version 3 of the 
 * License, or (at your option) any later version.
 * 
 * Ext.NET is distributed in the hope that it will be useful,
 * but WITHOUT ANY WARRANTY; without even the implied warranty of
 * MERCHANTABILITY or FITNESS FOR A PARTICULAR PURPOSE.  See the
 * GNU AFFERO GENERAL PUBLIC LICENSE for more details.
 * 
 * You should have received a copy of the GNU AFFERO GENERAL PUBLIC LICENSE
 * along with Ext.NET.  If not, see <http://www.gnu.org/licenses/>.
 *
 *
 * @version   : 2.0.0.beta - Community Edition (AGPLv3 License)
 * @author    : Ext.NET, Inc. http://www.ext.net/
 * @date      : 2012-03-07
 * @copyright : Copyright (c) 2007-2012, Ext.NET, Inc. (http://www.ext.net/). All rights reserved.
 * @license   : GNU AFFERO GENERAL PUBLIC LICENSE (AGPL) 3.0. 
 *              See license.txt and http://www.ext.net/license/.
 *              See AGPL License at http://www.gnu.org/licenses/agpl-3.0.txt
 ********/

using System;
using System.ComponentModel;
using System.Web.UI.WebControls;
using System.Web.UI;

namespace Ext.Net
{
    /// <summary>
    /// Creates a Pie Chart. A Pie Chart is a useful visualization technique to display quantitative information for different categories that also have a meaning as a whole. As with all other series, the Pie Series must be appended in the series Chart array configuration.
    /// </summary>
    [Meta]
    public partial class PieSeries : AbstractSeries
    {
        /// <summary>
        /// 
        /// </summary>
        public PieSeries()
        {
        }

        /// <summary>
        /// 
        /// </summary>
        [ConfigOption]
        protected virtual string Type
        {
            get
            {
                return "pie";
            }
        }

        protected internal override void BeforeSerialization()
        {
            base.BeforeSerialization();

            if (this.HighlightConfig != null && this.HighlightSegmentMargin != null)
            {
                this.HighlightConfig.CustomConfig.Add(new ConfigItem("segment", "{margin:" + HighlightSegmentMargin.Value + "}", ParameterMode.Raw));
            }
        }

        /// <summary>
        /// The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The store record field name to be used for the pie angles. The values bound to this field name must be positive real numbers.")]
        public virtual string AngleField
        {
            get
            {
                return this.State.Get<string>("AngleField", "");
            }
            set
            {
                this.State.Set("AngleField", value);
            }
        }

        /// <summary>
        /// An array of color values which will be used, in order, as the gauge slice fill colors.
        /// </summary>
        [Meta]
        [ConfigOption(typeof(StringArrayJsonConverter))]
        [TypeConverter(typeof(StringArrayConverter))]
        [DefaultValue(null)]
        [Description("An array of color values which will be used, in order, as the gauge slice fill colors.")]
        public virtual string[] ColorSet
        {
            get
            {
                return this.State.Get<string[]>("ColorSet", null);
            }
            set
            {
                this.State.Set("ColorSet", value);
            }
        }

        /// <summary>
        /// Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(0)]
        [Description("Whether to set the pie chart as donut chart. Default's false. Can be set to a particular percentage to set the radius of the donut chart.")]
        public virtual int Donut
        {
            get
            {
                return this.State.Get<int>("Donut", 0);
            }
            set
            {
                this.State.Set("Donut", value);
            }
        }

        /// <summary>
        /// The duration for the pie slice highlight effect. Defaults to: 150
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(150)]
        [Description("The duration for the pie slice highlight effect. Defaults to: 150")]
        public virtual int HighlightDuration
        {
            get
            {
                return this.State.Get<int>("HighlightDuration", 150);
            }
            set
            {
                this.State.Set("HighlightDuration", value);
            }
        }

        /// <summary>
        /// 
        /// </summary>
        [Meta]        
        [DefaultValue(null)]
        [Description("")]
        public virtual int? HighlightSegmentMargin
        {
            get
            {
                return this.State.Get<int?>("HighlightSegmentMargin", null);
            }
            set
            {
                this.State.Set("HighlightSegmentMargin", value);
            }
        }

        [ConfigOption("highlightCfg", JsonMode.Raw)]
        [DefaultValue("")]
        protected virtual string HighlightSegmentMarginProxy
        {
            get
            {
                if (this.HighlightConfig == null && this.HighlightSegmentMargin != null)
                {
                    return "{segment:{margin:" + HighlightSegmentMargin.Value + "}}";
                }

                return "";
            }
        }

        /// <summary>
        /// The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue("")]
        [Description("The store record field name to be used for the pie slice lengths. The values bound to this field name must be positive real numbers.")]
        public virtual string LengthField
        {
            get
            {
                return this.State.Get<string>("LengthField", "");
            }
            set
            {
                this.State.Set("LengthField", value);
            }
        }

        /// <summary>
        /// Whether to add the pie chart elements as legend items. Default's false.
        /// </summary>
        [Meta]
        [ConfigOption]
        [DefaultValue(false)]
        [Description("Whether to add the pie chart elements as legend items. Default's false.")]
        public override bool ShowInLegend
        {
            get
            {
                return this.State.Get<bool>("ShowInLegend", false);
            }
            set
            {
                this.State.Set("ShowInLegend", value);
            }
        }

        private SpriteAttributes style;

        /// <summary>
        /// An object containing styles for overriding series styles from Theming.
        /// </summary>
        [Meta]
        [ConfigOption(JsonMode.Object)]
        [DefaultValue(null)]
        [PersistenceMode(PersistenceMode.InnerProperty)]
        public SpriteAttributes Style
        {
            get
            {
                return this.style;
            }
            set
            {
                this.style = value;
            }
        }
    }
}
