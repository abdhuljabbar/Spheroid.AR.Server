namespace Spheroid.AR
{
    public readonly struct HeightOptions
    {
        public HeightRelativity Relativity { get; }
        public HeightAlignment Alignment { get; }
        public bool IsDefaultValue { get; }

        public HeightOptions(HeightRelativity relativity, HeightAlignment alignment, bool isDefaultValue)
        {
            Relativity = relativity;
            Alignment = alignment;
            IsDefaultValue = isDefaultValue;
        }
    }
}
