using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Reflection;
using System.Text;

namespace Task_Manager.Models
{
    public enum TaskItemStatus
    {
        [Description("New")]
        New,

        [Description("In progress")]
        InProgress,

        [Description("Completed")]
        Completed,

        [Description("Canceled")]
        Canceled
    } // Full finished
    public static class EnumHelper
    {
        public static string GetDescription(Enum value)
        {
            var field = value.GetType().GetField(value.ToString());

            var attribute = field?
                .GetCustomAttribute<DescriptionAttribute>();

            return attribute?.Description ?? value.ToString();
        }
    } // Full finished

}
