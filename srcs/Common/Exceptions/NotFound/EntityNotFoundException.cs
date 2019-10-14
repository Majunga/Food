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
    public class IngredientNotFoundException : RecordNotFoundException
    {
        public IngredientNotFoundException() { }
        public IngredientNotFoundException(int id) : base(id) { }
		public IngredientNotFoundException(string message) : base(message) { }
		public IngredientNotFoundException(string message, Exception inner) : base(message, inner) { }
        protected IngredientNotFoundException(SerializationInfo info, StreamingContext context) : base(info, context) { }

        public override string EntityType => "Ingredient";
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

}
