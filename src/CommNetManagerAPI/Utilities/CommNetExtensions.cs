﻿using System;
using System.Collections.Generic;
using System.Linq;
using CommNet;

namespace CommNetManagerAPI
{
    /// <summary>
    /// Extension methods for use with CommNet.
    /// </summary>
    public static class CommNetExtensions
    {
        internal static Dictionary<CommNode, Vessel> commNodesVessels = new Dictionary<CommNode, Vessel>();

        internal static Vessel GetVesselStock(this CommNode commNode)
        {
            return FlightGlobals.Vessels.FirstOrDefault(vessel => vessel != null && vessel.connection != null && vessel.connection.Comm == commNode);
        }
        internal static Vessel GetVesselCNM(this CommNode commNode)
        {
            Vessel vessel;
            if (!commNodesVessels.TryGetValue(commNode, out vessel))
                return null;
            return vessel;
        }

        /// <summary>
        /// Similar to <see cref="GetVessel(CommNode)"/> but returns a bool indicating success.
        /// </summary>
        /// <param name="commNode">The node to find the parent vessel of.</param>
        /// <param name="vessel">The returned vessel.</param>
        /// <returns>True if successful.</returns>
        public static bool TryGetVessel(this CommNode commNode, out Vessel vessel)
        {
            vessel = commNode.GetVessel();
            return vessel != null;
        }
        /// <summary>
        /// Gets the <see cref="Vessel"/>  associated with a <see cref="CommNode"/>.
        /// </summary>
        /// <param name="commNode">The node to find the parent vessel of.</param>
        public static Vessel GetVessel(this CommNode commNode)
        {
            return getVessel(commNode);
        }
        internal static Func<CommNode, Vessel> getVessel = GetVesselStock;

        /*/// <summary>
        /// Custom equality comparer for CommNodes.
        /// </summary>
        public static bool CNEquals(this CommNode a, CommNode b)
        {
            if (a == null || b == null) return false;
            return (a.precisePosition == b.precisePosition);
        }*/
    }
}
