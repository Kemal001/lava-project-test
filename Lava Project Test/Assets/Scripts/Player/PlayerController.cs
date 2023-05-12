using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class PlayerController : ITickable
{
    private readonly PlayerView _view;
    private readonly PlayerModel _model;

    public PlayerController(PlayerView view, PlayerModel model)
    {
        _view = view;
        _model = model;
    }

    void ITickable.Tick()
    {

    }
}
