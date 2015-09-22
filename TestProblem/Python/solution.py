# -*- coding: utf-8 -*-

def main():
    # Get data from the standard input
    num_lines = int(input())
    lines = []
    for i in range(num_lines):
        lines.append(input())
    
    # Show the result in the standard output
    print('.'.join(lines))


if __name__ == '__main__':
    main()