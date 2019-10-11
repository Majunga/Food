/*
 * ==== THIS IS A GENERATED FILE ====
 *  ===       DO NOT EDIT!       ===
 *
 * See the BoilerPlateException.tt file
 * In order to add a new "BoilerPlateException", add the Entity's name to the
 * "entities" array in BoilerPlateException.tt file
 *
 */
using System;
using System.Runtime.Serialization;
namespace Common.Exceptions.BoilerPlate
{

    // Generated via BoilerPlateException.tt
    [Serializable]
    public class InvalidUserException : Exception
    {
        public InvalidUserException() { }
		public InvalidUserException(string message) : base(message) { }
		public InvalidUserException(string message, Exception inner) : base(message, inner) { }
        protected InvalidUserException(SerializationInfo info, StreamingContext context) : base(info, context) { }
    }

}
