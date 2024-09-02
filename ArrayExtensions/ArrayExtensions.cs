namespace Shedule.ArrayExtensions
{
	static public class ArrayExtensions
	{

		static public string IsEmpty(this string SomeThing)
		{
			if (SomeThing == null || SomeThing == " ")
			{
				return "Пусто";
			}

			return SomeThing;
		}
	}
}
