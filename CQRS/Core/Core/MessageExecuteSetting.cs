﻿namespace Incoding.CQRS
{
    #region << Using >>

    using System;
    using System.Data;
    using Incoding.Extensions;

    #endregion

    public class MessageExecuteSetting
    {
        #region Constructors

        public MessageExecuteSetting() { }

        internal MessageExecuteSetting(MessageExecuteSettingAttribute attribute)
        {
            DataBaseInstance = attribute.DataBaseInstance;
            Connection = attribute.Connection;
            IsolationLevel = attribute.IsolationLevel;
        }

        internal MessageExecuteSetting(MessageExecuteSetting executeSetting)
        {
            DataBaseInstance = executeSetting.DataBaseInstance;
            Connection = executeSetting.Connection;
            IsolationLevel = executeSetting.IsolationLevel;
            UID = executeSetting.UID;
            //without IsOuter 
        }

        #endregion

    

        public string DataBaseInstance { get; set; }

        public string Connection { get; set; }

        public IsolationLevel? IsolationLevel { get; set; }

        public bool IsOuter { get; set; }

        public Guid UID { get; set; }


        #region Equals

        public override int GetHashCode()
        {
            unchecked
            {
                return ((DataBaseInstance != null ? DataBaseInstance.GetHashCode() : 0) * 397) ^
                       (Connection != null ? Connection.GetHashCode() : 0) ^
                       (IsolationLevel.HasValue ? IsolationLevel.GetHashCode() : 0);
            }
        }

        public override bool Equals(object obj)
        {
            return this.IsReferenceEquals(obj) && Equals(obj as MessageExecuteSetting);
        }

        protected bool Equals(MessageExecuteSetting other)
        {
            return string.Equals(DataBaseInstance, other.DataBaseInstance) &&
                   string.Equals(Connection, other.Connection) &&
                   IsolationLevel.Equals(other.IsolationLevel);
        }

        #endregion
    }
}