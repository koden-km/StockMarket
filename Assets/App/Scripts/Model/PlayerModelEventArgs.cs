namespace App.Model
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

}
