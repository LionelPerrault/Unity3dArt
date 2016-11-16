using Moggle.Controles;
using System;

namespace Units.Skills
{
	/// <summary>
	/// Represents a skill
	/// </summary>
	public interface ISkill : IDibujable, IComponent
	{
		/// <summary>
		/// Executes this <see cref="ISkill"/>
		/// </summary>
		/// <param name="user">The caster</param>
		void Execute (IUnidad user);

		/// <summary>
		/// Determines whether this skill is castable by the specified user.
		/// </summary>
		/// <returns><c>true</c> if this skill is castable by the specified user; otherwise, <c>false</c>.</returns>
		/// <param name="user">User</param>
		bool IsCastable (IUnidad user);

		/// <summary>
		/// Determines whether this instance is visible to the specified <see cref="IUnidad"/>
		/// </summary>
		/// <returns><c>true</c> if this instance is visible by the specified user; otherwise, <c>false</c></returns>
		/// <param name="user">User</param>
		bool IsVisible (IUnidad user);

		/// <summary>
		/// Occurs when the eexecution finishes completly
		/// </summary>
		event EventHandler Executed;
	}
}