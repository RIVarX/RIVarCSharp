# Reactive Instance Variables
Declarative, Efficient, Scalable

### Declaring

```C#
Variable x, y, z

z.Set(x/y)


```

means whenever *x* or *y* is changed, *z* is updated. 


```C#

x.OnNext(10)
y.OnNext(3) // z=3.33


```

### Efficient

```C#
Variable x, y, z

z.Set(x/y)
x.Set(y*z)



```

no redundant updates

```C#

x.OnNext(10)
y.OnNext(3) // z=3.33 , x has not changed


```

### Scalable
TBD


--------


Such assignment can bind variables in either directions, on the same object, or across two different objects; as a result the variables and bindings might form *any* network.

Unlike other frameworks, the updates are predictable, with no redundant updates and happens between the variables in a decentralized manner.

The set of variables aims to be a **consistent UI application state**: the variables contains the values that reflect the recent inputs and bindings which flow them.







