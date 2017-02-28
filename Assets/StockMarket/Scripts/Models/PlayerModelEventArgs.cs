namespace StockMarket.Models
{

	/// <summary>
	/// Player model changing event arguments.
	/// Dispatched when the player model is about to change.
	/// </summary>
	public class PlayerModelChangingEventArgs : System.EventArgs
	{
		/// <summary>
		/// The name of the field that is changing.
		/// </summary>
		public readonly string FieldName;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.PlayerModelChangingEventArgs"/> class.
		/// </summary>
		/// <param name="fieldName">The field name that is changing.</param>
		public PlayerModelChangingEventArgs(string fieldName)
		{
			FieldName = fieldName;
		}
	}


	/// <summary>
	/// Player model changed event arguments.
	/// Dispatched when the player model has changed.
	/// </summary>
	public class PlayerModelChangedEventArgs : System.EventArgs
	{
		/// <summary>
		/// The name of the field that has changed.
		/// </summary>
		public readonly string FieldName;

		/// <summary>
		/// Initializes a new instance of the <see cref="App.Model.PlayerModelChangedEventArgs"/> class.
		/// </summary>
		/// <param name="fieldName">The field name that has changed.</param>
		public PlayerModelChangedEventArgs(string fieldName)
		{
			FieldName = fieldName;
		}
	}





	// TODO: New plan.
	// Make specific event args that contain details of the chainging/changed values,
	// They should contain all the info that the listeners need, but keeps it separate
	// from sending the model as is.
	// Maybe still derive from a common abstract PlayerModelChang(ing|ed)EventArgs.
	// Something like this:

	/// <summary>
	/// Player model event arguments.
	/// </summary>
	public abstract class PlayerModelEventArgs : System.EventArgs
	{
	}

	/// <summary>
	/// Player name event arguments.
	/// </summary>
	public class PlayerNameEventArgs : PlayerModelEventArgs
	{
		/// <summary>
		/// The player name.
		/// </summary>
		public readonly string Name;

		/// <summary>
		/// Initializes a new instance of the <see cref="StockMarket.Models.PlayerNameEventArgs"/> class.
		/// </summary>
		/// <param name="name">The player name.</param>
		public PlayerNameEventArgs(string name)
		{
			Name = name;
		}
	}

}
