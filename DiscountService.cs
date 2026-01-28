public class DiscountService
{
    public double Calc(double amount, string type)
    {
        if (type == "VIP")
        {
            if (amount > 1000)
            {
                return amount * 0.2;
            }
            else
            {
                return amount * 0.1;
            }
        }
        else if (type == "Regular")
        {
            if (amount > 500)
            {
                return amount * 0.05;
            }
            else
            {
                return 0;
            }
        }
        return 0;
    }
}