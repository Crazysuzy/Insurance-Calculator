namespace CSharpCode.Services
{
    public static class FinanceService
    {
        public static int Insurance(int age, int baseCost, int months)
        {
            // Simple insurance calculation logic
            int ageFactor = age < 25 ? 2 : (age < 50 ? 1 : 3);
            return baseCost * ageFactor * months / 12;  // Assumed logic, can be modified
        }

        public static double CalculateTax(double income)
        {
            // Simple tax calculation based on income
            double taxRate = income < 50000 ? 0.1 : 0.2;
            return income * taxRate;  // Assumed logic, can be modified
        }
    }
}
