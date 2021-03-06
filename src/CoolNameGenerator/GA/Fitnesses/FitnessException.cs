using System;
using System.Runtime.Serialization;
using System.Security.Permissions;
using CoolNameGenerator.Helper;

namespace CoolNameGenerator.GA.Fitnesses
{
    /// <summary>
    ///     Exception throw when an error occurs during the execution of fitness evaluation.
    /// </summary>
    [Serializable]
    public sealed class FitnessException : Exception
    {
        #region Properties

        /// <summary>
        ///     Gets the fitness.
        /// </summary>
        /// <value>The fitness.</value>
        public IFitness Fitness { get; }

        #endregion

        #region Methods

        /// <summary>
        ///     Sets the <see cref="T:System.Runtime.Serialization.SerializationInfo" /> with information about the exception.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        /// <PermissionSet>
        ///     <IPermission
        ///         class="System.Security.Permissions.FileIOPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Read="*AllFiles*" PathDiscovery="*AllFiles*" />
        ///     <IPermission
        ///         class="System.Security.Permissions.SecurityPermission, mscorlib, Version=2.0.3600.0, Culture=neutral, PublicKeyToken=b77a5c561934e089"
        ///         version="1" Flags="SerializationFormatter" />
        /// </PermissionSet>
        [SecurityPermission(SecurityAction.LinkDemand, Flags = SecurityPermissionFlag.SerializationFormatter)]
        public override void GetObjectData(SerializationInfo info, StreamingContext context)
        {
            base.GetObjectData(info, context);
            info.AddValue("Fitness", Fitness);
        }

        #endregion

        #region Constructors

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        /// <param name="fitness">The fitness where occurred the error.</param>
        /// <param name="message">The error message.</param>
        public FitnessException(IFitness fitness, string message)
            : base("{0}: {1}".With(fitness?.GetType().Name ?? string.Empty, message))
        {
            Fitness = fitness;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        /// <param name="fitness">The fitness where occurred the error.</param>
        /// <param name="message">The error message.</param>
        /// <param name="innerException">Inner exception.</param>
        public FitnessException(IFitness fitness, string message, Exception innerException)
            : base("{0}: {1}".With(fitness?.GetType().Name ?? string.Empty, message), innerException)
        {
            Fitness = fitness;
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        public FitnessException()
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        /// <param name="message">The message that describes the error.</param>
        public FitnessException(string message)
            : base(message)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        /// <param name="message">The error message that explains the reason for the exception.</param>
        /// <param name="innerException">
        ///     The exception that is the cause of the current exception, or a null reference (Nothing in
        ///     Visual Basic) if no inner exception is specified.
        /// </param>
        public FitnessException(string message, Exception innerException)
            : base(message, innerException)
        {
        }

        /// <summary>
        ///     Initializes a new instance of the <see cref="FitnessException" /> class.
        /// </summary>
        /// <param name="info">
        ///     The <see cref="T:System.Runtime.Serialization.SerializationInfo" /> that holds the serialized object
        ///     data about the exception being thrown.
        /// </param>
        /// <param name="context">
        ///     The <see cref="T:System.Runtime.Serialization.StreamingContext" /> that contains contextual
        ///     information about the source or destination.
        /// </param>
        private FitnessException(SerializationInfo info, StreamingContext context)
            : base(info, context)
        {
        }

        #endregion
    }
}