﻿//-----------------------------------------------------------------------
// <copyright file="AuthorizationRule.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Base class providing basic authorization rule</summary>
//-----------------------------------------------------------------------

using Csla.Core;
using Csla.Properties;

namespace Csla.Rules
{
  /// <summary>
  /// Base class providing basic authorization rule
  /// implementation.
  /// </summary>
  public abstract class AuthorizationRuleAsync : IAuthorizationRuleAsync
  {
    private IMemberInfo? _element;
    private AuthorizationActions _action;
    private bool _cacheResult = true;
    private bool _locked = false;

    /// <summary>
    /// Creates an instance of the rule.
    /// </summary>
    /// <param name="action">Action this rule will enforce.</param>
    public AuthorizationRuleAsync(AuthorizationActions action)
    {
      _action = action;
    }
    /// <summary>
    /// Creates an instance of the rule.
    /// </summary>
    /// <param name="action">Action this rule will enforce.</param>
    /// <param name="element">Method or property.</param>
    /// <exception cref="ArgumentNullException"><paramref name="element"/> is <see langword="null"/>.</exception>
    public AuthorizationRuleAsync(AuthorizationActions action, IMemberInfo element)
      : this(action)
    {
      _element = element ?? throw new ArgumentNullException(nameof(element));
    }
    /// <summary>
    /// Authorization rule implementation.
    /// </summary>
    /// <param name="context">Rule context object.</param>
    /// <param name="ct">The cancellation token.</param>
    protected abstract Task ExecuteAsync(IAuthorizationContext context, CancellationToken ct);

    /// <summary>
    /// Gets a value indicating whether the results
    /// of this rule can be cached at the business
    /// object level.
    /// </summary>
    /// <returns>bool, true by default to allow cache result.</returns>
    public bool CacheResult
    {
      get => _cacheResult;
      protected set
      {
        CanWriteProperty("CacheResult");
        _cacheResult = value;
      }
    }

    /// <summary>
    /// Gets the name of the element (property/method)
    /// to which this rule is associated.
    /// </summary>
    public IMemberInfo? Element
    {
      get => _element;
      set
      {
        CanWriteProperty("Element");
        _element = value;
      }
    }
    /// <summary>
    /// Gets the authorization action this rule
    /// will enforce.
    /// </summary>
    public AuthorizationActions Action
    {
      get => _action;
      set
      {
        CanWriteProperty("Action");
        _action = value;
      }
    }

    private void CanWriteProperty(string argument)
    {
      if (_locked)
        throw new ArgumentException($"{Resources.PropertySetNotAllowed} ({argument})", argument);
    }

    #region IAuthorizationRuleAsync

    /// <inheritdoc />
    async Task IAuthorizationRuleAsync.ExecuteAsync(IAuthorizationContext context, CancellationToken ct)
    {
      if (context is null)
        throw new ArgumentNullException(nameof(context));

      if (!_locked)
        _locked = true;
      await ExecuteAsync(context, ct);
    }

    /// <summary>
    /// Gets the authorization action this rule
    /// will enforce.
    /// </summary>
    AuthorizationActions IAuthorizationRuleBase.Action => Action;

    #endregion

    #region Read Property
    /// <summary>
    /// Reads a property's field value.
    /// </summary>
    /// <param name="obj">
    /// Object on which to call the method. 
    /// </param>
    /// <param name="propertyInfo">
    /// PropertyInfo object containing property metadata.</param>
    /// <remarks>
    /// No authorization checks occur when this method is called.
    /// </remarks>
    /// <exception cref="ArgumentNullException"><paramref name="obj"/> or <paramref name="propertyInfo"/> is <see langword="null"/>.</exception>
    protected object? ReadProperty(object obj, IPropertyInfo propertyInfo)
    {
      if (obj is null)
        throw new ArgumentNullException(nameof(obj));
      if (propertyInfo is null)
        throw new ArgumentNullException(nameof(propertyInfo));

      if (obj is IManageProperties target)
        return target.ReadProperty(propertyInfo);
      else
        throw new ArgumentException(Resources.IManagePropertiesRequiredException);
    }

    #endregion
  }
}