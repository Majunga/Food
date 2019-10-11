using System;
using AutoMapper;

namespace Common.Conversion
{
    public class AutoMapperConversionService : IConversionService
    {
        private readonly IMapper _engine;

        #region Constructors

        /// <summary>
        /// Creates a new instance of <see cref="AutoMapperConversionService"/>
        /// </summary>
        public AutoMapperConversionService(IMapper engine)
        {
            _engine = engine ?? throw new ArgumentNullException(nameof(engine));
        }

        #endregion

        public object Convert(object source, Type targetType)
        {
            if (targetType == null) throw new ArgumentNullException(nameof(targetType));
            if (source == null) return targetType.IsValueType ? Activator.CreateInstance(targetType) : null;

            try
            {
                return _engine.Map(source, source.GetType(), targetType);
            }
            catch (AutoMapperConfigurationException ex)
            {
                throw new AutoMapperMappingException(ex.Message, ex);
            }
            catch (AutoMapperMappingException ex)
            {
                if (ex.MemberMap == null)
                {
                    throw new AutoMapperMappingException(ex.Message, ex);
                }

                if (ex.InnerException != null)
                {
                    // this is not ideal as we lose the call stack in the exception, but we need to preserve the original 
                    // exception to prevent AutoMapper from leaking into the application.  We could create a new instance 
                    // of the original exception, and throw that, with the AutoMapper as the inner exception, but it's
                    // difficult to preserve the data when constructing a new instance (e.g. as discovered with 
                    // DataValidationException)
                    throw ex.InnerException;
                }

                throw;
            }
        }


        public void Map(object source, object target)
        {
            if (source == null) throw new ArgumentNullException(nameof(source));
            if (target == null) throw new ArgumentNullException(nameof(target));
            try
            {
                _engine.Map(source, target, source.GetType(), target.GetType());
            }
            catch (AutoMapperMappingException ex)
            {
                if (ex.MemberMap == null)
                {
                    throw new AutoMapperMappingException(ex.Message, ex);
                }

                if (ex.InnerException != null)
                {
                    // this is not ideal as we lose the call stack in the exception, but we need to preserve the original 
                    // exception to prevent AutoMapper from leaking into the application.  We could create a new instance 
                    // of the original exception, and throw that, with the AutoMapper as the inner exception, but it's
                    // difficult to preserve the data when constructing a new instance (e.g. as discovered with 
                    // DataValidationException)
                    throw ex.InnerException;
                }

                throw;
            }
        }
    }
}
