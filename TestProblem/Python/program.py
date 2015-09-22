# -*- coding: utf-8 -*-

# Get data from the standard input
num_lines = int(input())
lines = []
for i in range(num_lines):
    lines.append(input())

# Show the result in the standard output
print('.'.join(lines))
