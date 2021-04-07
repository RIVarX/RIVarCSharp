# Reactive Instance Variables
Declarative, Efficient, Scalable

### Declarative

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

The cycles in the relations does not cause redundant updates

```C#

x.OnNext(10)
y.OnNext(3) // z = 3.33 , x has not changed


```

### Scalable
You can connect variables on the same object, or across different objects.  




The plurality of variables aims to be a **consistent UI application state**: the variables contains the values that reflect the recent inputs.







