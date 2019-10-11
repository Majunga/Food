using System;
using System.Runtime.Serialization;

namespace Common.Exceptions.NotFound
{
    [Serializable]
    public abstract class RecordNotFoundException : Exception
    {
        private const int Undefined = 0;
        private const string IdKey = "EntityId";
        private readonly int? _entityId;

        protected RecordNotFoundException() { }

        protected RecordNotFoundException(int id)
        {
            _entityId = id;
        }

        protected RecordNotFoundException(string message) : base(message) { }

        protected RecordNotFoundException(string message, Exception inner) : base(message, inner) { }

        protected RecordNotFoundException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
            var id = info.GetInt32(IdKey);
            if (id != Undefined)
            {
                _entityId = id;
            }
        }

        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);

            info.AddValue(IdKey, EntityId ?? Undefined);
        }

        public override string Message
        {
            get
            {
                if (EntityId.HasValue)
                {
                    return string.Format("A {0} could not be found for the identifier {1}", EntityType, EntityId.Value);
                }
                return base.Message;
            }
        }

        /// <summary>
        /// Describes the missing entity
        /// </summary>
        public abstract string EntityType { get; }

        public int? EntityId => _entityId;
    }
}