using Newtonsoft.Json;
using System.Collections.Generic;
using UnityEngine;

// LeaderBoard leaderBoard = JsonConvert.DeserializeObject<LeaderBoard>(data);
namespace YandexLeaderBoard
{
    [CreateAssetMenu(fileName = "LeaderBoardData", menuName = "YandexSDK/LeaderBoard", order = 1)]

    public class LeaderBoardData : ScriptableObject
    {
        [JsonProperty(PropertyName = "entries")]
        public List<Entry> Entries { get; set; }

        [JsonProperty(PropertyName = "leaderboard")]
        public Board Board { get; set; }

        [JsonProperty(PropertyName = "ranges")]
        public List<Range> Ranges { get; set; }

        [JsonProperty(PropertyName = "userRank")]
        public int UserRank { get; set; }
    }

    public class Description
    {
        [JsonProperty(PropertyName = "invert_sort_order")]
        public bool InvertSortOrder { get; set; }

        [JsonProperty(PropertyName = "score_format")]
        public ScoreFormat ScoreFormat { get; set; }
    }

    public class Entry
    {
        [JsonProperty(PropertyName = "score")]
        public int Score { get; set; }

        [JsonProperty(PropertyName = "extraData")]
        public string ExtraData { get; set; }

        [JsonProperty(PropertyName = "rank")]
        public int Rank { get; set; }

        [JsonProperty(PropertyName = "player")]
        public Player Player { get; set; }

        [JsonProperty(PropertyName = "formattedScore")]
        public string FormattedScore { get; set; }
    }

    public class Board
    {
        [JsonProperty(PropertyName = "appID")]
        public int AppID { get; set; }

        [JsonProperty(PropertyName = "name")]
        public string Name { get; set; }

        [JsonProperty(PropertyName = "default")]
        public bool Default { get; set; }

        [JsonProperty(PropertyName = "description")]
        public Description Description { get; set; }

        [JsonProperty(PropertyName = "title")]
        public Title Title { get; set; }
    }

    public class Options
    {
        [JsonProperty(PropertyName = "decimal_offset")]
        public int DecimalOffset { get; set; }
    }

    public class Player
    {
        [JsonProperty(PropertyName = "lang")]
        public string Lang { get; set; }

        [JsonProperty(PropertyName = "publicName")]
        public string PublicName { get; set; }

        [JsonProperty(PropertyName = "scopePermissions")]
        public ScopePermissions ScopePermissions { get; set; }

        [JsonProperty(PropertyName = "uniqueID")]
        public string UniqueID { get; set; }
    }

    public class Range
    {
        [JsonProperty(PropertyName = "start")]
        public int Start { get; set; }

        [JsonProperty(PropertyName = "size")]
        public int Size { get; set; }
    }

    public class ScopePermissions
    {
        [JsonProperty(PropertyName = "avatar")]
        public string Avatar { get; set; }

        [JsonProperty(PropertyName = "public_name")]
        public string PublicName { get; set; }
    }

    public class ScoreFormat
    {
        [JsonProperty(PropertyName = "type")]
        public string Type { get; set; }

        [JsonProperty(PropertyName = "options")]
        public Options Options { get; set; }
    }

    public class Title
    {
        [JsonProperty(PropertyName = "en")]
        public string En { get; set; }

        [JsonProperty(PropertyName = "ru")]
        public string Ru { get; set; }
    }
}