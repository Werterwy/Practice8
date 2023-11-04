using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Practice8
{
    using System;

    public class SalesForecast
    {
        private double[] salesData;

        public SalesForecast(double[] data)
        {
            salesData = data;
        }

        // Индексатор для доступа к данным о продажах по месяцам
        public double this[int month]
        {
            get
            {
                if (month >= 0 && month < salesData.Length)
                {
                    return salesData[month];
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Недопустимый месяц");
                }
            }
            set
            {
                if (month >= 0 && month < salesData.Length)
                {
                    salesData[month] = value;
                }
                else
                {
                    throw new ArgumentOutOfRangeException("Недопустимый месяц");
                }
            }
        }

        // Линейная регрессия с использованием метода наименьших квадратов
        public double[] LinearRegression(int futureMonths)
        {
            int n = salesData.Length;
            double sumX = 0;
            double sumY = 0;
            double sumXY = 0;
            double sumX2 = 0;

            for (int i = 0; i < n; i++)
            {
                sumX += i;
                sumY += salesData[i];
                sumXY += i * salesData[i];
                sumX2 += i * i;
            }

            double a = (n * sumXY - sumX * sumY) / (n * sumX2 - sumX * sumX);
            double b = (sumY - a * sumX) / n;

            double[] forecast = new double[futureMonths];

            for (int i = 0; i < futureMonths; i++)
            {
                forecast[i] = a * (n + i) + b;
            }

            return forecast;
        }
    }
}
