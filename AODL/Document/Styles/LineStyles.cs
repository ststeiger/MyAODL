/*
 * $Id: LineStyles.cs,v 1.1 2006/01/29 11:28:23 larsbm Exp $
 */

/*
 * License: 
 * GNU Lesser General Public License. You should recieve a
 * copy of this within the library. If not you will find
 * a whole copy at http://www.gnu.org/licenses/lgpl.html .
 * 
 * Author:
 * Copyright 2006, Lars Behrmann, lb@OpenDocument4all.com
 * 
 * Last changes:
 * 
 */

using System;

namespace AODL.Document.Styles
{
	/// <summary>
	/// Represents the possible line styles used in OpenDocument.
	/// e.g for the FormatedText.Underline
	/// </summary>
	public class LineStyles
	{
		/// <summary>
		/// long-dash
		/// </summary>
		public static readonly string longdash	= "long-dash";
		/// <summary>
		/// dot-dash
		/// </summary>
		public static readonly string dotdash	= "dot-dash";
		/// <summary>
		/// dot-dot-dash
		/// </summary>
		public static readonly string dotdotdash	= "dot-dot-dash";
		/// <summary>
		/// No style
		/// </summary>
		public static readonly string none	= "none";
		/// <summary>
		/// solid
		/// </summary>
		public static readonly string solid	= "solid";
		/// <summary>
		/// dotted
		/// </summary>
		public static readonly string dotted	= "dotted";
		/// <summary>
		/// dash
		/// </summary>
		public static readonly string dash	= "dash";
		/// <summary>
		/// wave
		/// </summary>
		public static readonly string wave	= "wave";
	}

	/// <summary>
	/// Border helper class
	/// </summary>
	public class Border
	{
		/// <summary>
		/// Normal solid
		/// </summary>
		public static readonly string NormalSolid	= "0.002cm solid #000000";
		/// <summary>
		/// Middlle solid
		/// </summary>
		public static readonly string MiddleSolid	= "0.004cm solid #000000";
		/// <summary>
		/// Heavy solid
		/// </summary>
		public static readonly string HeavySolid	= "0.008cm solid #000000";
	}
}

/*
 * $Log: LineStyles.cs,v $
 * Revision 1.1  2006/01/29 11:28:23  larsbm
 * - Changes for the new version. 1.2. see next changelog for details
 *
 * Revision 1.4  2005/11/23 19:18:17  larsbm
 * - New Textproperties
 * - New Paragraphproperties
 * - New Border Helper
 * - Textproprtie helper
 *
 * Revision 1.3  2005/10/22 15:52:10  larsbm
 * - Changed some styles from Enum to Class with statics
 * - Add full support for available OpenOffice fonts
 *
 * Revision 1.2  2005/10/08 07:55:35  larsbm
 * - added cvs tags
 *
 */