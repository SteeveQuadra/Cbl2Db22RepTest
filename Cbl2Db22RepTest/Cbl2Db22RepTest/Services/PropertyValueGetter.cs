using System.Reflection;

namespace Cbl2Db22RepTest.Services
{
	public interface IPropertyValueGetter
	{
		object Get(object item, string propertyName);
	}
	public class PropertyValueGetter : IPropertyValueGetter
	{
		public PropertyValueGetter()
		{

		}

		public object Get(object item, string propertyName)
		{
			object newObject = null;
			if (propertyName == "this" || propertyName.ToLower() == "me")
				return item;
			PropertyInfo pinfo = DonnePropriete(item, propertyName, ref newObject);

			return DonneValeurPropriete(newObject, pinfo);
		}


		private PropertyInfo DonnePropriete(object item, string dataField, ref object newObject)
		{
			if (item == null)
				return null;

			while (dataField.IndexOf(".") != -1)
			{
				string propriete = dataField.Substring(0, dataField.IndexOf("."));
				item = item.GetType().GetProperty(propriete).GetValue(item, null);
				dataField = dataField.Substring(dataField.IndexOf(".") + 1);
				if (item == null)
					return null;
			}

			newObject = item;
			return item.GetType().GetProperty(dataField);
		}

		private object DonneValeurPropriete(object item, PropertyInfo pinfo)
		{
			if (pinfo == null || item == null)
				return null;
			return pinfo.GetValue(item, null);
		}
	}
}
