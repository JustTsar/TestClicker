using System;
using DG.Tweening;
using Lean.Pool;
using UnityEngine;
using Utility;

namespace Core.Effect
{
    public class EffectController : SingletonBehavior<EffectController>
    {
        [SerializeField] private MoneyEffect _moneyEffectPrefab;

        [SerializeField] private Transform _spawnPoint;
        [SerializeField] private Transform _targetMovePoint;

        [SerializeField] private TweenSettings _tweenSettings;
        

        public void SpawnEffect(float value)
        {
            var effect = LeanPool.Spawn(_moneyEffectPrefab, _spawnPoint);

            effect.SetValue(value);
            MoveObjectToTarget(effect);
        }

        private void MoveObjectToTarget(MoneyEffect effect)
        {
            Sequence _sequence = DOTween.Sequence();
            
            _sequence
                .Append(effect.transform.DOScale(Vector3.one, _tweenSettings.TimeToMaxScale))
                .Append(effect.transform.DOMove(_targetMovePoint.transform.position, _tweenSettings.TimeToMove).SetEase(Ease.OutSine))
                .Append(effect.transform.DOScale(Vector3.zero, _tweenSettings.TimeToMinScale)).OnComplete(() =>
                {
                    effect.DOKill();
                    LeanPool.Despawn(effect);
                });

            _sequence.Play();
        }
    }

    [Serializable]
    public class TweenSettings
    {
        public float TimeToMaxScale;
        public float TimeToMinScale;
        public float TimeToMove;
    }
}