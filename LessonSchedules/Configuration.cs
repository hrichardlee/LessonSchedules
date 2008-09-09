using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Xml.Linq;
using System.Xml;

namespace LessonSchedules {
    class LSConfiguration {
        const string configFileName = "LessonSchedules.config";

        XDocument theDoc;

        public LSConfiguration() {
            if( !File.Exists( configFileName ) ) {
                theDoc = new XDocument(
                    new XElement( "settings",
                        new XElement( "holidays" ),
                        new XElement( "recitals" )
                    )
                );
                Save();
            } else {
                theDoc = XDocument.Load( configFileName );
            }
        }

        #region holidays
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

        IEnumerable<XElement> HolidayElementFromName( string name ) {
            return from holidayEl in theDoc.Root.Element( "holidays" ).Elements( "holiday" )
                   where holidayEl.Attribute( "name" ).Value == name
                   select holidayEl;
        }

        //public List<string> HolidayList {
        //    get {
        //        List<string> theList = new List<string>();
        //        foreach( XElement holidayEl in theDoc.Root.Element( "holidays" ).Elements( "holiday" ) )
        //            theList.Add( holidayEl.Attribute( "name" ).Value );

        //        return theList;
        //    }
        //}

        public List<Holiday> HolidayList {
            get {
                List<Holiday> theList = new List<Holiday>();
                foreach( XElement holidayEl in theDoc.Root.Element( "holidays" ).Elements( "holiday" ) )
                    theList.Add( new Holiday( holidayEl ) );

                return theList;
            }
        }

        #endregion holidays

        #region recitals

        /// <summary>
        /// Returns whether already exists or not
        /// </summary>
        public bool AddRecital( Recital r ) {
            if( RecitalElementFromDate( r.Day ) != null ) {
                return false;
            } else {
                theDoc.Root.Element( "recitals" ).Add( r.ToXml() );
                this.Save();
                return true;
            }
        }

        public void DeleteRecital( DateTime date ) {
            XElement recitalEl = RecitalElementFromDate( date );
            if( recitalEl != null )
                recitalEl.Remove();
        }

        /// <summary>
        /// Returns null if not found
        /// </summary>
        XElement RecitalElementFromDate( DateTime date ) {
            foreach( XElement recitalEl in theDoc.Root.Element( "recitals" ).Elements( "recital" ) ) {
                Recital r = new Recital( recitalEl );
                if( r.Day.Day == date.Day &&
                    r.Day.Month == date.Month &&
                    r.Day.Year == date.Year )
                    return recitalEl;
            }

            return null;
        }

        public List<Recital> RecitalList {
            get {
                List<Recital> theList = new List<Recital>();
                foreach( XElement recitalEl in theDoc.Root.Element( "recitals" ).Elements( "recital" ) )
                    theList.Add( new Recital( recitalEl ) );
                return theList;
            }
        }

        #endregion recitals

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

    class Recital {
        const XmlDateTimeSerializationMode serializationMode = XmlDateTimeSerializationMode.Local;
        const string format = "dddd MM/dd/yy";
        public DateTime Day;
        public string Name;

        public Recital( DateTime pDay, string pName ) {
            Day = pDay;
            Name = pName;
        }

        public Recital( XElement recitalEl ) {
            Day = XmlConvert.ToDateTime( recitalEl.Value, serializationMode );
            Name = recitalEl.Attribute( "name" ).Value;
        }

        public XElement ToXml() {
            return new XElement( "recital",
                new XAttribute( "name", Name ),
                XmlConvert.ToString( Day, serializationMode )
            );
        }

        public override string ToString() {
            return Day.ToString( format ) + ": " + Name;
        }
    }
}
