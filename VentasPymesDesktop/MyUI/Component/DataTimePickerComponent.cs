using System;
using System.Windows.Forms;

namespace MyUI.Component
{
    internal class DataTimePickerComponent
    {
        public void inicializarDateTime(ref DateTimePicker dateTime, DateTime fechaInicio, DateTime fechaFin, DateTime value)
        {
            dateTime.Value= value;
            dateTime.MinDate = fechaInicio;
            dateTime.MaxDate = fechaFin;
            dateTime.Format = DateTimePickerFormat.Custom;           
        }
    }
}
