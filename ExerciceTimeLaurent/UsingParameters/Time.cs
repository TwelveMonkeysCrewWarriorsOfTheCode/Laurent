using System;
using System.Collections.Generic;
using System.Text;

namespace UsingParameters
{
    public class Time
    {
        //(*2*) Chiffre magique
        const int MINUTES_IN_HOUR = 60;
        //Variable accessible seulement dans la class Time implémenté par un constructeur  
        //Est implémenté quand vous assigné un objet Time(int, int)(*1*) ou Time(int)(*3*) ou Time(float)(*4*)
        private int m_TotalMinutes;

        #region Propriétés
        //Transforme m_TotalMinutes en heure par une division entière (exemple : m_TotalMinutes(127)/MINUTES_IN_HOUR(*2*) = 2, Hour = 2)
        public int Hour => m_TotalMinutes / MINUTES_IN_HOUR;
        //Transforme m_TotalMinutes en minute par un modulo (exemple : m_TotalMinutes(127) % MINUTES_IN_HOUR(*2*) = 7, Minute = 7)
        public int Minute => m_TotalMinutes % MINUTES_IN_HOUR;
        #endregion

        #region Constructeur
        //(*3*)
        public Time(int pTimeMinute) => m_TotalMinutes = pTimeMinute;
        //(*4*)
        public Time(float pTimeFloat) => m_TotalMinutes = (int)(Math.Round(pTimeFloat * MINUTES_IN_HOUR));
        //(*1*)Implémente le variable m_TotalMinutes par la méthode ParseTimeToMinute(int, int)
        public Time(int pHour, int pMinute) => ParseTimeToMinute(pHour, pMinute);
        #endregion


        #region Méthodes
        //(*1*)Méthode qui implémente m_TotalMinutes avec les heures transformées en minutes et les minutes de l'objet Time
        private void ParseTimeToMinute(int pHour, int pMinute) => m_TotalMinutes = pHour * MINUTES_IN_HOUR + pMinute;
        public override string ToString() => $"{Hour:##00}:{Minute:00} min"; 
        #endregion

        #region Opérateur
        /// <summary>
        /// Tranforme un int en Time
        /// </summary>
        /// <param name="pTime">Time</param>
        public static explicit operator int(Time pTime) => pTime.m_TotalMinutes;

        /// <summary>
        /// Transforme un float en int
        /// </summary>
        /// <param name="pTime">Time</param>
        public static explicit operator float(Time pTime) => (float)pTime.m_TotalMinutes / MINUTES_IN_HOUR;

        /// <summary>
        /// Transforme un Time en int
        /// </summary>
        /// <param name="pTime">int</param>
        public static explicit operator Time(int pTime) => new Time(pTime);

        /// <summary>
        /// Transforme un float en Time
        /// </summary>
        /// <param name="pTime">float</param>
        public static explicit operator Time(float pTime) => new Time(pTime);

        /// <summary>
        /// Additionne un Time avec un Time
        /// </summary>
        /// <param name="pLeftTime">Time</param>
        /// <param name="pRightTime">Time</param>
        /// <returns>>Objet Time</returns>
        public static Time operator +(Time pLeftTime, Time pRightTime) => new Time((int)pLeftTime + (int)pRightTime);

        /// <summary>
        /// Soustrait un Time avec un Time
        /// </summary>
        /// <param name="pLeftTime">Time</param>
        /// <param name="pRightTime">Time</param>
        /// <returns>>Objet Time</returns>
        public static Time operator -(Time pLeftTime, Time pRightTime) => new Time((int)pLeftTime - (int)pRightTime);

        /// <summary>
        /// Multiple un Time par un int 
        /// </summary>
        /// <param name="pTime">Time</param>
        /// <param name="pNumMult">int</param>
        /// <returns>Objet Time</returns>
        public static Time operator *(Time pTime, int pNumMult) => new Time((int)pTime * pNumMult);

        /// <summary>
        /// Divise un Time par un int
        /// </summary>
        /// <param name="pTime">Time</param>
        /// <param name="pNumDiv">int</param>
        /// <returns>Objet Time</returns>
        public static Time operator /(Time pTime, int pNumDiv) => new Time((int)pTime / pNumDiv);

        /// <summary>
        /// Compare si Time1 < Time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>bool</returns>
        public static bool operator <(Time pTimeLeft, Time pTimeRight) => pTimeLeft.m_TotalMinutes < pTimeRight.m_TotalMinutes;

        /// <summary>
        /// Compare si Time1 > Time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>bool</returns>
        public static bool operator >(Time pTimeLeft, Time pTimeRight) => pTimeLeft.m_TotalMinutes > pTimeRight.m_TotalMinutes;

        /// <summary>
        /// Compare si Time1 <= Time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>bool</returns>
        public static bool operator <=(Time pTimeLeft, Time pTimeRight) => pTimeLeft.m_TotalMinutes <= pTimeRight.m_TotalMinutes;

        /// <summary>
        /// Compare si Time1 >= Time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>bool</returns>
        public static bool operator >=(Time pTimeLeft, Time pTimeRight) => pTimeLeft.m_TotalMinutes >= pTimeRight.m_TotalMinutes;

        // Teste sans retourner un bool mais une string
        
        /// <summary>
        /// Compare si time == time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>string si == vrai alors " est égal à " sinon " n'est pas égal à "</returns>
        public static string operator ==(Time pTimeLeft, Time pTimeRight) => (pTimeLeft.m_TotalMinutes == pTimeRight.m_TotalMinutes) ? "est égal à" : "n'est pas égal à";
        /// <summary>
        /// Compare si time != time2
        /// </summary>
        /// <param name="pTimeLeft">Time</param>
        /// <param name="pTimeRight">Time</param>
        /// <returns>string si != vrai alors " n'est pas égal à " sinon " est égal à "</returns>
        public static string operator !=(Time pTimeLeft, Time pTimeRight) => (pTimeLeft.m_TotalMinutes != pTimeRight.m_TotalMinutes) ? "n'est pas égal à" : "est égal à";

        // Fin teste

        /// <summary>
        /// Fait le modulo d'un time
        /// </summary>
        /// <param name="time">Time</param>
        /// <param name="modulo">int</param>
        /// <returns>int</returns>
        public static int operator %(Time time, int modulo) => time.m_TotalMinutes % modulo; 
        #endregion
    }
}
