﻿// Based on [System.Reactive.Disposables]: https://github.com/dotnet/reactive
// Licensed to the .NET Foundation under one or more agreements.
// The .NET Foundation licenses this file to you under the MIT License.
// See the LICENSE file in the project root for more information. 

namespace Weknow.Disposables
{
    /// <summary>
    /// Disposable resource with disposal state tracking.
    /// </summary>
    public interface IStateCancelable<TState>: ICancelable 
    {
        /// <summary>
        /// Gets a value that indicates whether the object is disposed.
        /// </summary>
        TState State { get; set; }
    }
}