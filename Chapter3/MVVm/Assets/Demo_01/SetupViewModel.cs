using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SetupViewModel
{
   public BindableProperty<string>Name = new BindableProperty<string>();
   public BindableProperty<string>Job = new BindableProperty<string>();
   public BindableProperty<int> ATK = new BindableProperty<int>();
   public BindableProperty<float>SuccessRate = new BindableProperty<float>();
   public BindableProperty<Random.State> State = new BindableProperty<Random.State>();

}
