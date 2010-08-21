using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;
using System.Globalization;

namespace LessonSchedules {
    class LSConfiguration {
        string configFileName = "LessonSchedules.config";
        const string dateFormat = "dd/MM/yyyy";

        XDocument theDoc;

        public LSConfiguration() {
            if( !File.Exists( configFileName ) ) {
                theDoc = new XDocument(
                    new XElement( "settings",
                        new XElement( "holidays" ),
                        new XElement( "glDates" ),
                        new XElement( "general" )
                    )
                );
                Save();
            } else {
                theDoc = XDocument.Load( configFileName );
            }

            configFileName = Path.GetFullPath(configFileName);
        }

        #region general

        public string GetGeneralSetting(string name)
        {
            XElement found = theDoc.Root.Element("general").Element(name);
            if (found == null)
                return null;
            else
                return found.Value;
        }

        public void SetGeneralSetting(string name, string value)
        {
            XElement found = theDoc.Root.Element("general").Element(name);
            if (found == null)
            {
                found = new XElement(name, value);
                theDoc.Root.Element("general").Add(found);
            }
            else
            {
                found.Value = value;
            }

            Save();
        }

        #endregion

        #region holidays

        private IEnumerable<XElement> HolidayElementFromName(string name)
        {
            return from holidayEl in theDoc.Root.Element("holidays").Elements("holiday")
                   where holidayEl.Attribute("name").Value == name
                   select holidayEl;
        }

        /// <summary>
        /// Returns whether the name conflicts
        /// </summary>
        public bool AddHoliday( Holiday h ) {
            if( HolidayElementFromName( h.Name ).Count() > 0 )
                return false;

            theDoc.Root.Element( "holidays" ).Add( h.ToXml() );
            this.Save();

            return true;
        }

        /// <summary>
        /// throws ApplicationException if config file corrupt
        /// </summary>
        public bool UpdateHoliday( string oldName, Holiday toAdd ) {
            if( toAdd.Name != oldName &&
                HolidayElementFromName( toAdd.Name ).Count() > 0 )
                return false;

            IEnumerable<XElement> elementsToEdit = HolidayElementFromName( oldName );
            if( elementsToEdit.Count() != 1 )
                throw new ApplicationException( "Config file corrupted" );

            elementsToEdit.First().ReplaceWith( toAdd.ToXml() );
            this.Save();
            return true;
        }

        /// <summary>
        /// Throws ApplicationException if not found
        /// </summary>
        public Holiday GetHoliday( string name ) {
            IEnumerable<XElement> elementsToEdit = HolidayElementFromName( name );
            if( elementsToEdit.Count() != 1 )
                throw new ApplicationException( "Config file corrupted" );

            return new Holiday( elementsToEdit.First() );
        }

        public void DeleteHoliday( string name ) {
            HolidayElementFromName( name ).Remove();
        }

        public IList<Holiday> HolidayList {
            get {
                List<Holiday> theList = new List<Holiday>();
                foreach( XElement holidayEl in theDoc.Root.Element( "holidays" ).Elements( "holiday" ) )
                    theList.Add( new Holiday( holidayEl ) );

                return theList;
            }
        }

        #endregion holidays

        #region group lesson

        private IEnumerable<XElement> GLElementFromDate(DateTime date)
        {
            return from glEl in theDoc.Root.Element("glDates").Elements("glDate")
                   where DateTime.ParseExact(glEl.Attribute("date").Value,
                                    dateFormat, CultureInfo.CurrentCulture)
                                == date
                   select glEl;
        }

        private XElement GlDateToXml(DateTime gl)
        {
            return
                new XElement("glDate",
                    new XAttribute("date", gl.ToString(dateFormat)));
        }

        private DateTime GlDateFromXml(XElement el)
        {
            return DateTime.ParseExact(el.Attribute("date").Value, dateFormat, CultureInfo.CurrentCulture);
        }

        public bool AddGLDate(DateTime gl)
        {
            if (GLElementFromDate(gl).Count() > 0)
                return false;

            theDoc.Root.Element("glDates").Add(GlDateToXml(gl));
            this.Save();

            return true;
        }

        public void DeleteGLDate(DateTime gl)
        {
            GLElementFromDate(gl).Remove();
        }

        public void DeleteAllGLDates()
        {
            theDoc.Root.Element("glDates").Elements("glDate").Remove();
        }

        public IList<DateTime> GLDateList
        {
            get
            {
                SortedSet<DateTime> theList = new SortedSet<DateTime>();
                foreach (XElement glEl in theDoc.Root.Element("glDates").Elements())
                    theList.Add(GlDateFromXml(glEl));

                return theList.ToList();
            }
        }

        #endregion

        void Save() {
            theDoc.Save( configFileName );
        }
    }

    class Holiday {
        const XmlDateTimeSerializationMode serializationMode = XmlDateTimeSerializationMode.Local;
        public string Name;
        public DateTime FirstDay;
        public DateTime LastDay;

        public Holiday( string pName, DateTime pFirstDay, DateTime pLastDay ) {
            Name = pName;
            FirstDay = pFirstDay;
            LastDay = pLastDay;
        }

        public Holiday( XElement holidayEl ) {
            Name = holidayEl.Attribute( "name" ).Value;
            FirstDay = XmlConvert.ToDateTime( holidayEl.Element( "firstday" ).Value, serializationMode );
            LastDay = XmlConvert.ToDateTime( holidayEl.Element( "lastday" ).Value, serializationMode );
        }

        public XElement ToXml() {
            return
                new XElement( "holiday",
                    new XAttribute( "name", Name ),
                    new XElement( "firstday", XmlConvert.ToString( FirstDay, serializationMode ) ),
                    new XElement( "lastday", XmlConvert.ToString( LastDay, serializationMode ) )
                );
        }

        public bool Contains( DateTime toTest ) {
            return toTest >= FirstDay && toTest <= LastDay;
        }

        public override string ToString() {
            return Name;
        }
    }
}
