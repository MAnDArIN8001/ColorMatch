using System;
using UnityEngine;

public class CartPicker : MonoBehaviour
{
    public event Action<int> OnPickedFigure;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Figure>(out var figure))
        {
            int figureScore = figure.CollectScore;

            Color ownCurrentColor = gameObject.GetComponent<CartColorController>().CurrentColor;
            Color figureColor = figure.CurrentCollor;

            figureScore *= ownCurrentColor == figureColor ? 1 : -1;

            figure.PickUp();

            OnPickedFigure?.Invoke(figureScore);
        }
    }
}
