# **弹反系统技术报告（Day4）**

## **一、实现方案**

### 1. **弹反检测机制**

- 输入响应

  ：通过UniRx的

  ```c#
  UpdateAsObservable()
  ```

  监听按键事件，触发武器Layer切换

  

  ```c#
  csharp复制// 示例代码（InputHandler.cs ）
  inputStream.Where(_ => Input.GetButtonDown("Parry"))
      .Subscribe(_ => weaponCollider.gameObject.layer  = LayerMask.NameToLayer("Parry"))
      .AddTo(this);
  ```

- **碰撞检测**：武器子模块设置`Layer="Parry"`，与敌人`Layer="EnemyAttack"`进行物理过滤

### 2. **敌人行为控制**

- 状态机架构

  ：基于FSM实现三状态切换（Idle→SawTarget→FollowTarget->Attack）

  

  ```c#
  public void ChangeActiveState(FSMStateID stateID)
  {
      // 离开上一个状态
      currentState.ExitState(this);
      print(currentState.stateID);
      // 设置当前状态
      if (stateID == defaultStateID)
      {
          currentState = defaultState;
      }
      else
          currentState = states.Find(states => states.stateID == stateID);
      // 进入下一个状态
      currentState.EnterState(this);
      print(currentState.stateID);
  
  }
  ```

- **攻击碰撞控制**：通过AnimationEvent在攻击关键帧激活/关闭碰撞体

------

## **二、已验证风险点**

### 1. **事件释放验证**

- UniRx订阅链均添加`AddTo(disposables)`，场景切换时订阅数归零

### 2. **Layer冲突验证**

- 通过Physics设置矩阵过滤，排除`Parry`层与`Environment`层的交互

------

## **三、核心代码片段**

### 1. **UniRx事件绑定**

```c#

MessageBroker.Default.Receive<ParryResultEvent>()
    .Subscribe(result => {
        currentStamina += result.success  ? 20 : -10;
        staminaUI.UpdateValue(currentStamina);
    }).AddTo(disposables);
```

### 2. **FSM状态机逻辑**

```c#

通过FSM框架实现。框架的主体分为3个板块。
    FSMBase---记录所有状态的列表，在FSMBase类中配置所有状态和条件的对应关系。
    		记录当前状态、初始时默认状态
    		在update生命周期函数中不断调用当前状态的SelectState方法。
    		并提供切换状态的方法--离开当前状态、进入目标状态。
    FSMTrigger类存放当前条件的检测方法，
    FSMState记录这个状态下对应的条件能转换到的对应的接下来的状态，并且提供SelectState方法用于检测所有条件并切换至符合条件的状态。
 在FSMBase中使用Update生命周期函数不断检测当前状态切换到下一个状态的条件是否满足（遍历所有条件）如果满足就在该状态类中调用切换状态的方法--传入下一个状态的ID。

```

------

