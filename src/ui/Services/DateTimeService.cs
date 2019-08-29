namespace StartPagePlus.UI.Services
{
    using System;
    using Core.Interfaces;

    public class DateTimeService : IDateTimeService
    {
        public DateTime Today => DateTime.Today;
    }
}