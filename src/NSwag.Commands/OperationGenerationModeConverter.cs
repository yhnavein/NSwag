﻿//-----------------------------------------------------------------------
// <copyright file="OperationGenerationModeConverterv.cs" company="NSwag">
//     Copyright (c) Rico Suter. All rights reserved.
// </copyright>
// <license>https://github.com/NSwag/NSwag/blob/master/LICENSE.md</license>
// <author>Rico Suter, mail@rsuter.com</author>
//-----------------------------------------------------------------------

using NSwag.CodeGeneration.OperationNameGenerators;
using NSwag.Commands.CodeGeneration;

namespace NSwag.Commands
{
    internal class OperationGenerationModeConverter
    {
        internal static OperationGenerationMode GetOperationGenerationMode(IOperationNameGenerator operationNameGenerator)
        {
            if (operationNameGenerator is MultipleClientsFromOperationIdOperationNameGenerator)
                return OperationGenerationMode.MultipleClientsFromOperationId;
            if (operationNameGenerator is MultipleClientsFromPathSegmentsOperationNameGenerator)
                return OperationGenerationMode.MultipleClientsFromPathSegments;
            if (operationNameGenerator is SingleClientFromOperationIdOperationNameGenerator)
                return OperationGenerationMode.SingleClientFromOperationId;
            if (operationNameGenerator is SingleClientFromPathSegmentsOperationNameGenerator)
                return OperationGenerationMode.SingleClientFromPathSegments;
            return OperationGenerationMode.MultipleClientsFromOperationId;
        }

        internal static IOperationNameGenerator GetOperationNameGenerator(OperationGenerationMode operationGenerationMode)
        {
            if (operationGenerationMode == OperationGenerationMode.MultipleClientsFromOperationId)
                return new MultipleClientsFromOperationIdOperationNameGenerator();
            else if (operationGenerationMode == OperationGenerationMode.MultipleClientsFromPathSegments)
                return new MultipleClientsFromPathSegmentsOperationNameGenerator();
            else if (operationGenerationMode == OperationGenerationMode.SingleClientFromOperationId)
                return new SingleClientFromOperationIdOperationNameGenerator();
            else if (operationGenerationMode == OperationGenerationMode.SingleClientFromPathSegments)
                return new SingleClientFromPathSegmentsOperationNameGenerator();
            else
                return new MultipleClientsFromOperationIdOperationNameGenerator();
        }
    }
}
