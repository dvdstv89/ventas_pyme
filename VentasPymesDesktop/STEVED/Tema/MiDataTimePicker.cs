using System;
using System.Globalization;
using System.Windows.Forms;

namespace NucleoEV.Tema
{
    public class MiDataTimePicker
    {
        public void inicializarDateTime(ref DateTimePicker dateTime, CultureInfo cultureInfo, DateTime fechaInicio, DateTime fechaFin, DateTime value)
        {
            dateTime.Value= value;
            dateTime.MinDate = fechaInicio;
            dateTime.MaxDate = fechaFin;
            dateTime.Format = DateTimePickerFormat.Custom;
            //string[] formats = dateTime.Value.GetDateTimeFormats(cultureInfo);
            //dateTime.CustomFormat = formats[0];
        }
    }
}
