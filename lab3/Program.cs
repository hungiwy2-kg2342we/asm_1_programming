using System;

class WaterBillCalculator
{
    static void Main(string[] args)
    {
        // Nhập thông tin khách hàng
        Console.Write("The customer name: ");
        string customerName = Console.ReadLine();
        Console.Write("Enter last month's water meter reading: ");
        int lastMonthReading = int.Parse(Console.ReadLine());

        Console.Write("Enter this month's water meter reading: ");
        int thisMonthReading = int.Parse(Console.ReadLine());

        // Tính lượng tiêu thụ
        int consumption = thisMonthReading - lastMonthReading;

        // Nhập loại khách hàng
        Console.WriteLine("Which household do you belong ");
        Console.WriteLine("1. Household customer");
        Console.WriteLine("2. Administrative agency, public services");
        Console.WriteLine("3. Production units");
        Console.WriteLine("4. Business services");
        int customerType = int.Parse(Console.ReadLine());

        // Tính hóa đơn nước
        double totalBill = CalculateBill(customerType, consumption);

        // Hiển thị thông tin khách hàng và hóa đơn
        Console.WriteLine("Profile customer :");
        Console.WriteLine("Name customer: " + customerName);
        Console.WriteLine("Number water last month: " + lastMonthReading);
        Console.WriteLine("Number water this month: " + thisMonthReading);
        Console.WriteLine("Consumption: " + consumption + " m3");
        Console.WriteLine("Total bill of you: " + totalBill.ToString("0.00") + " VND");

        Console.ReadLine();
    }
    //tính toán tổng hóa đơn dựa trên loại khách hàng và lượng tiêu thụ
    static double CalculateBill(int customerType, int consumption)
    {
        double pricePerM3 = 0;
        double environmentFeePerM3 = 0;

        switch (customerType)
        {
            case 1: // Hộ gia đình
                Console.Write("Enter the number of people in the household:");
                int numberOfPeople = int.Parse(Console.ReadLine());
                pricePerM3 = CalculateHouseholdBill(numberOfPeople, consumption, out environmentFeePerM3);
                break;
            case 2: // Cơ quan hành chính, dịch vụ công cộng
                pricePerM3 = 9.955;
                environmentFeePerM3 = 0.9955;
                break;
            case 3: // Đơn vị sản xuất
                pricePerM3 = 11.615;
                environmentFeePerM3 = 1.1615;
                break;
            case 4: // Dịch vụ kinh doanh
                pricePerM3 = 22.068;
                environmentFeePerM3 = 2.2068;
                break;
            default:
                Console.WriteLine("There is no type of customer");
                break;
        }
        double totalWithoutVAT = (pricePerM3 + environmentFeePerM3) * consumption;
        double VAT = totalWithoutVAT * 0.10;
        double totalWithVAT = totalWithoutVAT + VAT;

        return totalWithVAT;
    }
    static double CalculateHouseholdBill(int numberOfPeople, int consumption, out double environmentFeePerM3)
    {
        environmentFeePerM3 = 0;
        double totalBill = 0;
        double pricePerM3;

        for (int i = 0; i < numberOfPeople; i++)
        {
            int consumptionPerPerson = consumption / numberOfPeople;
            if (consumptionPerPerson <= 10)
            {
                pricePerM3 = 5.973;
                environmentFeePerM3 += 0.5973;
            }
            else if (consumptionPerPerson <= 20)
            {
                pricePerM3 = 7.052;
                environmentFeePerM3 += 0.7052;
            }
            else if (consumptionPerPerson <= 30)
            {
                pricePerM3 = 8.699;
                environmentFeePerM3 += 0.8669;
            }
            else
            {
                pricePerM3 = 15.929;
                environmentFeePerM3 += 1.5929;
            }
            totalBill += pricePerM3 * consumptionPerPerson;
        }

        return totalBill;
    }
}