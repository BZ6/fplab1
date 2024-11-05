number = 600851475143

n = number
factor = 2
while n > 1:
    if n % factor == 0:
        n /= factor
    else:
        factor += 1
result = factor

print(result)
