using System;

namespace AttributeProvider 
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field | AttributeTargets.Event | AttributeTargets.Method)]
    public class IgnoreContentAttribute : Attribute
    {

    }
}