﻿//-----------------------------------------------------------------------
// <copyright file="PersonSerializationInfoFactory.cs" company="Marimer LLC">
//     Copyright (c) Marimer LLC. All rights reserved.
//     Website: https://cslanet.com
// </copyright>
// <summary>Factory for the creation of test SerializationInfo instances</summary>
//-----------------------------------------------------------------------
using System;
using System.Collections.Generic;
using System.Text;
using Csla.Generator.AutoSerialization.CSharp.TestObjects;
using Csla.Serialization.Mobile;

namespace Csla.Generator.AutoSerialization.CSharp.Tests.Helpers
{
  internal static class PersonSerializationInfoFactory
  {

    internal static SerializationInfo GetDefaultSerializationInfo()
    {
      SerializationInfo serializationInfo;

      serializationInfo = new SerializationInfo(1, AssemblyNameTranslator.GetSerializationName(typeof(PersonPOCO), true));
      serializationInfo.AddValue("_middleName", "");
      serializationInfo.AddValue("PersonId", 5);
      serializationInfo.AddValue("FirstName", "");
      serializationInfo.AddValue("LastName", "");
      serializationInfo.AddValue("DateOfBirth", DateTime.MinValue);
      serializationInfo.AddValue("NonSerializedText", "");
      serializationInfo.AddValue("PrivateText", "");
      serializationInfo.AddValue("PrivateSerializedText", "");

      return serializationInfo;
    }

  }
}
