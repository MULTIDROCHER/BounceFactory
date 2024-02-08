using System.Collections.Generic;
using BounceFactory.System.Level;
using UnityEngine;

namespace BounceFactory.System.Game
{
    public class LevelPrepairer
    {
        private readonly List<LevelData> _templates;
        private readonly List<Sprite> _sprites;

        public LevelPrepairer(List<LevelData> templates, List<Sprite> sprites)
        {
            _templates = templates;
            _sprites = sprites;
        }

        public LevelData GetRandomLevel(LevelData current)
        {
            var newLevel = current;

            foreach (var level in _templates)
            {
                if (level != null)
                    level.gameObject.SetActive(false);
            }

            while (newLevel == current || newLevel == null)
                newLevel = _templates[Random.Range(0, _templates.Count)];

            return newLevel;
        }

        public Sprite GetRandomBackground() => _sprites[Random.Range(0, _sprites.Count)];
    }
}