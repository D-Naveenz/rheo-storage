namespace Rheo.Extensions.Hosting.Argument
{
    /// <summary>
    /// Specifies the type of a commandline argument in a <see cref="CommandlineArgHandler"/>
    /// </summary>
    /// <remarks>This enumeration supports bitwise combination of its values using the <see
    /// cref="FlagsAttribute"/>. Use the <see cref="None"/> value to indicate no arguments, or combine multiple
    /// values to represent a combination of argument types.</remarks>
    [Flags]
    public enum ArgumentType
    {
        None = 0,                   // 0 (0b0000)
        Lunch = 1 << 0,             // 1 (0b0001)
        Runtime = 1 << 1,           // 2 (0b0010)
        System = 1 << 2,            // 4 (0b0100)
        ValueRequired = 1 << 3,     // 8 (0b1000)
    }
}
