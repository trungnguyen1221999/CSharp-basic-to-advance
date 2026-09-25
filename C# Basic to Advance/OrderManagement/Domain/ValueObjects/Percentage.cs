public record struct Percentage
{
   public decimal Value { get; set; }

   public Percentage(decimal value)
   {
       if (value < 0 || value > 100)
       {
           throw new ArgumentOutOfRangeException(nameof(value), "Percentage must be between 0 and 100.");
       }
       Value = value;
   }

   public decimal ToMultiplier()
    {
        return 1- Value / 100m;
    }
}