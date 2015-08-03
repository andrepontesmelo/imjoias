/************************************************************
 * Developped by Júlio César e Melo <cmelo_bhz@hotmail.com> *
 ************************************************************/

using System;
using System.Collections;
using System.Reflection;
using System.Xml;

namespace Report.Layout
{
	/// <summary>
	/// Item which should be printed.
	/// </summary>
	public abstract class Mapping
	{
		// Constants
		private const string		notPropertyNeitherFieldException = "Only propertys and fields can be set as members to be mapped";

		// Data member
		protected MemberInfo		member;
		protected Type				memberType;

		/// <summary>
		/// Set member which contains the data to be printed.
		/// </summary>
		/// <param name="member">Member which contains the data</param>
		/// <param name="memberType">Data type</param>
		protected virtual void SetMember(MemberInfo member, Type memberType)
		{
			this.member		= member;
			this.memberType = memberType;
		}

		/// <summary>
		/// Set member which contains the data to be printed.
		/// </summary>
		/// <param name="type">Type which contains data to be printed</param>
		/// <param name="member">Member's name which contains the data</param>
		protected virtual void SetMember(Type type, string member)
		{
			this.member		= type.GetProperty(member);

			if (this.member != null)
			{
				this.memberType = ((PropertyInfo) this.member).PropertyType;
				return;
			}

			this.member = type.GetField(member);

			if (this.member != null)
			{
				this.memberType = ((FieldInfo) this.member).FieldType;
				return;
			}

			throw new ArgumentException(notPropertyNeitherFieldException + "\nMember: " + member, "member");
		}

		/// <summary>
		/// Set member which contains the data to be printed.
		/// </summary>
		/// <param name="element">Member's description on a Xml element</param>
		protected virtual void SetMember(XmlElement element, IDictionary typeDictionary)
		{
			string typeName;
			string memberName;
			Type   type;

			// Get type's name and member's name from Xml
			typeName = element.GetAttribute("Type");
			memberName = element.GetAttribute("Name");

			// Get type from assembly
			type = (Type) typeDictionary[typeName];

			// BeginInvokes default SetMember
			SetMember(type, memberName);
		}

		/// <summary>
		/// Class member that contains data to be printed.
		/// </summary>
		[System.ComponentModel.Category("Mapping")]
		[System.ComponentModel.Browsable(false)]
		public MemberInfo Member
		{
			get { return member; }
			set
			{
				switch (value.MemberType)
				{
					case MemberTypes.Property:
						SetMember(value, ((PropertyInfo) member).PropertyType);
						break;

					case MemberTypes.Field:
						SetMember(value, ((FieldInfo) member).FieldType);
						break;

					default:
						throw new ArgumentException(notPropertyNeitherFieldException);
				}
			}
		}

		/// <summary>
		/// Data type
		/// </summary>
		[System.ComponentModel.Category("Mapping")]
		[System.ComponentModel.Browsable(false)]
		public Type MemberType
		{
			get { return memberType; }
		}

		/// <summary>
		/// Checks if object is from the same type than
		/// member's class type.
		/// </summary>
		/// <param name="obj">Object to be checked against
		/// member's class type</param>
		/// <returns>True if obj is from the same type</returns>
		public bool MatchTypeObject(object obj)
		{
			return member.ReflectedType == obj.GetType();
		}

		/// <summary>
		/// Gets a mapped value
		/// </summary>
		/// <param name="obj">Object containing data to be printed</param>
		/// <returns>Value to be printed</returns>
		protected virtual object GetValue(object obj)
		{
			switch (member.MemberType)
			{
				case MemberTypes.Property:
					return ((PropertyInfo) member).GetValue(
						obj, null);

				case MemberTypes.Field:
					return ((FieldInfo) member).GetValue(obj);
			}

            throw new NotSupportedException();
		}
	}
}
