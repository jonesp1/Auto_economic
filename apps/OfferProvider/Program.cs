public class OfferProvider
{
    protected string? offerText;

    public virtual void DisplayOffer()
    {
        Console.WriteLine(offerText);
    }
}

public class CalculatorOfferProvider : OfferProvider
{

    public CalculatorOfferProvider(string calculatorContent)
    {
        offerText = calculatorContent;
    }

    public double CalculateHouseLoan(double loanAmount, double interestRate, int loanTermInMonths)
    {
        double monthlyInterestRate = interestRate / 12 / 100;


        double monthlyPayment = loanAmount * (monthlyInterestRate * Math.Pow(1 + monthlyInterestRate, loanTermInMonths)) /
                                (Math.Pow(1 + monthlyInterestRate, loanTermInMonths) - 1);

        return monthlyPayment;
    }
}

class Program
{
    static async Task Main(string[] args)
    {



        await Demo.Foo();


    }
}

