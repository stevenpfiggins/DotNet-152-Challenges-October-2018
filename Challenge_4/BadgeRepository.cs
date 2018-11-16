using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Challenge_4
{
    class BadgeRepository
    {
        Dictionary<int, List<string>> _badgeDictionary = new Dictionary<int, List<string>>();

        public void AddBadgeToDictionary(Badge badge)
        {
            _badgeDictionary.Add(badge.BadgeID, badge.DoorAccess);
        }

        public Dictionary<int, List<string>> ShowDictionaryContents()
        {
            return _badgeDictionary;
        }

        public void UpdateDoorAccess(int badgeID, List<string> doorValues)
        {
            _badgeDictionary[badgeID] = doorValues;
        }

        public void RemoveDoorAccess(int badgeID)
        {
            _badgeDictionary.Remove(badgeID);
        }
    }
}
