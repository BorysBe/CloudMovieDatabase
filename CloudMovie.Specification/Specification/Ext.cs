using System;
using FluentAssertions;
using FluentAssertions.Execution;
using FluentAssertions.Primitives;
using Newtonsoft.Json;

namespace CloudMovie.Specification.Specification
{
    public static class Ext
    {
        public static AndConstraint<StringAssertions> BeDeserializedTo<T>(this StringAssertions resp,
            out T deserialized)
        {
            deserialized = default(T);
            try
            {
                deserialized = JsonConvert.DeserializeObject<T>(resp.Subject);
            }
            catch (Exception e)
            {
                Execute.Assertion.ForCondition(false)
                    .FailWith("Cannot deserialize JSON-response. " + e);
            }

            return new AndConstraint<StringAssertions>(resp);
        }
    }
}