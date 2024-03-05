namespace AreaCalculator.Shapes;

/* Не понял, что подразумевалось по compile-time, склонялись, что хотели увидеть наследование, если нет, то
 на ум приходит что-то вроде паттерна visitor или каких-то подобных, но это из той же оперы и не уместно тут  */
public interface IShape
{
    public double CalculateArea();
}