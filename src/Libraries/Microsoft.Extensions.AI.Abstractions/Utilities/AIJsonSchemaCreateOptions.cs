﻿// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT license.

using System;
using System.Text.Json.Nodes;

#pragma warning disable S1067 // Expressions should not be too complex

namespace Microsoft.Extensions.AI;

/// <summary>
/// Provides options for configuring the behavior of <see cref="AIJsonUtilities"/> JSON schema creation functionality.
/// </summary>
public sealed class AIJsonSchemaCreateOptions : IEquatable<AIJsonSchemaCreateOptions>
{
    /// <summary>
    /// Gets the default options instance.
    /// </summary>
    public static AIJsonSchemaCreateOptions Default { get; } = new AIJsonSchemaCreateOptions();

    /// <summary>
    /// Gets a callback that is invoked for every schema that is generated within the type graph.
    /// </summary>
    public Func<AIJsonSchemaCreateContext, JsonNode, JsonNode>? TransformSchemaNode { get; init; }

    /// <summary>
    /// Gets a value indicating whether to include the type keyword in inferred schemas for .NET enums.
    /// </summary>
    public bool IncludeTypeInEnumSchemas { get; init; } = true;

    /// <summary>
    /// Gets a value indicating whether to generate schemas with the additionalProperties set to false for .NET objects.
    /// </summary>
    public bool DisallowAdditionalProperties { get; init; } = true;

    /// <summary>
    /// Gets a value indicating whether to include the $schema keyword in inferred schemas.
    /// </summary>
    public bool IncludeSchemaKeyword { get; init; }

    /// <summary>
    /// Gets a value indicating whether to mark all properties as required in the schema.
    /// </summary>
    public bool RequireAllProperties { get; init; } = true;

    /// <inheritdoc/>
    public bool Equals(AIJsonSchemaCreateOptions? other)
    {
        return other is not null &&
            TransformSchemaNode == other.TransformSchemaNode &&
            IncludeTypeInEnumSchemas == other.IncludeTypeInEnumSchemas &&
            DisallowAdditionalProperties == other.DisallowAdditionalProperties &&
            IncludeSchemaKeyword == other.IncludeSchemaKeyword &&
            RequireAllProperties == other.RequireAllProperties;
    }

    /// <inheritdoc />
    public override bool Equals(object? obj) => obj is AIJsonSchemaCreateOptions other && Equals(other);

    /// <inheritdoc />
    public override int GetHashCode() => (TransformSchemaNode, IncludeTypeInEnumSchemas, DisallowAdditionalProperties, IncludeSchemaKeyword, RequireAllProperties).GetHashCode();
}
