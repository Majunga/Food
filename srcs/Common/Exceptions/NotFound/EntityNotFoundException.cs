/*
 * ==== THIS IS A GENERATED FILE ====
 *  ===       DO NOT EDIT!       ===
 *
 * See the EntityNotFoundException.tt file
 * In order to add a new "EntityNotFoundException", add the Entity's name to the
 * "entities" array in EntityNotFoundException.tt file
 *
 */
using System;
using System.Runtime.Serialization;
namespace Common.Exceptions.NotFound
{

    // Generated via EntityNotFoundException.tt
    [Serializable]
    public class RequestNotFoundException : RecordNotFoundException
    {
        public RequestNotFoundException() { }
        public RequestNotFoundException(int id) : base(id) { }
		public RequestNotFoundException(string message) : base(message) { }
		public RequestNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected RequestNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "Request";
    }

    // Generated via EntityNotFoundException.tt
    [Serializable]
    public class CommandHandlerNotFoundException : RecordNotFoundException
    {
        public CommandHandlerNotFoundException() { }
        public CommandHandlerNotFoundException(int id) : base(id) { }
		public CommandHandlerNotFoundException(string message) : base(message) { }
		public CommandHandlerNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected CommandHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "CommandHandler";
    }

    // Generated via EntityNotFoundException.tt
    [Serializable]
    public class QueryHandlerNotFoundException : RecordNotFoundException
    {
        public QueryHandlerNotFoundException() { }
        public QueryHandlerNotFoundException(int id) : base(id) { }
		public QueryHandlerNotFoundException(string message) : base(message) { }
		public QueryHandlerNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected QueryHandlerNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "QueryHandler";
    }

    // Generated via EntityNotFoundException.tt
    [Serializable]
    public class UserProfileNotFoundException : RecordNotFoundException
    {
        public UserProfileNotFoundException() { }
        public UserProfileNotFoundException(int id) : base(id) { }
		public UserProfileNotFoundException(string message) : base(message) { }
		public UserProfileNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected UserProfileNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "UserProfile";
    }

    // Generated via EntityNotFoundException.tt
    [Serializable]
    public class WorkspaceNotFoundException : RecordNotFoundException
    {
        public WorkspaceNotFoundException() { }
        public WorkspaceNotFoundException(int id) : base(id) { }
		public WorkspaceNotFoundException(string message) : base(message) { }
		public WorkspaceNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected WorkspaceNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "Workspace";
    }

}
