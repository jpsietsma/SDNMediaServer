/** 
 * Kendo UI v2019.1.220 (http://www.telerik.com/kendo-ui)                                                                                                                                               
 * Copyright 2019 Progress Software Corporation and/or one of its subsidiaries or affiliates. All rights reserved.                                                                                      
 *                                                                                                                                                                                                      
 * Kendo UI commercial licenses may be obtained at                                                                                                                                                      
 * http://www.telerik.com/purchase/license-agreement/kendo-ui-complete                                                                                                                                  
 * If you do not own a commercial license, this file shall be governed by the trial license terms.                                                                                                      
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       
                                                                                                                                                                                                       

*/
(function (f, define) {
    define('kendo.selectable', [
        'kendo.core',
        'kendo.userevents'
    ], f);
}(function () {
    var __meta__ = {
        id: 'selectable',
        name: 'Selectable',
        category: 'framework',
        depends: [
            'core',
            'userevents'
        ],
        advanced: true
    };
    (function ($, undefined) {
        var kendo = window.kendo, Widget = kendo.ui.Widget, proxy = $.proxy, abs = Math.abs, ARIASELECTED = 'aria-selected', SELECTED = 'k-state-selected', ACTIVE = 'k-state-selecting', SELECTABLE = 'k-selectable', CHANGE = 'change', NS = '.kendoSelectable', UNSELECT = 'unselect', UNSELECTING = 'k-state-unselecting', INPUTSELECTOR = 'input,a,textarea,.k-multiselect-wrap,select,button,.k-button>span,.k-button>img,span.k-icon.k-i-arrow-60-down,span.k-icon.k-i-arrow-60-up,label.k-checkbox-label.k-no-text', msie = kendo.support.browser.msie, supportEventDelegation = false;
        (function ($) {
            (function () {
                $('<div class="parent"><span /></div>').on('click', '>*', function () {
                    supportEventDelegation = true;
                }).find('span').click().end().off();
            }());
        }($));
        var Selectable = Widget.extend({
            init: function (element, options) {
                var that = this, multiple;
                Widget.fn.init.call(that, element, options);
                that._marquee = $('<div class=\'k-marquee\'><div class=\'k-marquee-color\'></div></div>');
                that._lastActive = null;
                that.element.addClass(SELECTABLE);
                that.relatedTarget = that.options.relatedTarget;
                multiple = that.options.multiple;
                if (this.options.aria && multiple) {
                    that.element.attr('aria-multiselectable', true);
                }
                that.userEvents = new kendo.UserEvents(that.element, {
                    global: true,
                    allowSelection: true,
                    filter: (!supportEventDelegation ? '.' + SELECTABLE + ' ' : '') + that.options.filter,
                    tap: proxy(that._tap, that),
                    touchAction: multiple ? 'none' : 'pan-x pan-y'
                });
                if (multiple) {
                    that.userEvents.bind('start', proxy(that._start, that)).bind('move', proxy(that._move, that)).bind('end', proxy(that._end, that)).bind('select', proxy(that._select, that));
                }
            },
            events: [
                CHANGE,
                UNSELECT
            ],
            options: {
                name: 'Selectable',
                filter: '>*',
                inputSelectors: INPUTSELECTOR,
                multiple: false,
                relatedTarget: $.noop
            },
            _isElement: function (target) {
                var elements = this.element;
                var idx, length = elements.length, result = false;
                target = target[0];
                for (idx = 0; idx < length; idx++) {
                    if (elements[idx] === target) {
                        result = true;
                        break;
                    }
                }
                return result;
            },
            _tap: function (e) {
                var target = $(e.target), that = this, ctrlKey = e.event.ctrlKey || e.event.metaKey, multiple = that.options.multiple, shiftKey = multiple && e.event.shiftKey, selected, whichCode = e.event.which, buttonCode = e.event.button;
                if (!that._isElement(target.closest('.' + SELECTABLE)) || whichCode && whichCode == 3 || buttonCode && buttonCode == 2) {
                    return;
                }
                if (!this._allowSelection(e.event.target)) {
                    return;
                }
                selected = target.hasClass(SELECTED);
                if (!multiple || !ctrlKey) {
                    that.clear();
                }
                target = target.add(that.relatedTarget(target));
                if (shiftKey) {
                    that.selectRange(that._firstSelectee(), target, e);
                } else {
                    if (selected && ctrlKey) {
                        that._unselect(target);
                        that._notify(CHANGE, e);
                    } else {
                        that.value(target, e);
                    }
                    that._lastActive = that._downTarget = target;
                }
            },
            _start: function (e) {
                var that = this, target = $(e.target), selected = target.hasClass(SELECTED), currentElement, ctrlKey = e.event.ctrlKey || e.event.metaKey;
                if (!this._allowSelection(e.event.target)) {
                    return;
                }
                that._downTarget = target;
                if (!that._isElement(target.closest('.' + SELECTABLE))) {
                    that.userEvents.cancel();
                    return;
                }
                if (that.options.useAllItems) {
                    that._items = that.element.find(that.options.filter);
                } else {
                    currentElement = target.closest(that.element);
                    that._items = currentElement.find(that.options.filter);
                }
                e.sender.capture();
                that._marquee.appendTo(document.body).css({
                    left: e.x.client + 1,
                    top: e.y.client + 1,
                    width: 0,
                    height: 0
                });
                if (!ctrlKey) {
                    that.clear();
                }
                target = target.add(that.relatedTarget(target));
                if (selected) {
                    that._selectElement(target, true);
                    if (ctrlKey) {
                        target.addClass(UNSELECTING);
                    }
                }
            },
            _move: function (e) {
                var that = this, position = {
                        left: e.x.startLocation > e.x.location ? e.x.location : e.x.startLocation,
                        top: e.y.startLocation > e.y.location ? e.y.location : e.y.startLocation,
                        width: abs(e.x.initialDelta),
                        height: abs(e.y.initialDelta)
                    };
                that._marquee.css(position);
                that._invalidateSelectables(position, e.event.ctrlKey || e.event.metaKey);
                e.preventDefault();
            },
            _end: function (e) {
                var that = this;
                that._marquee.remove();
                that._unselect(that.element.find(that.options.filter + '.' + UNSELECTING)).removeClass(UNSELECTING);
                var target = that.element.find(that.options.filter + '.' + ACTIVE);
                target = target.add(that.relatedTarget(target));
                that.value(target, e);
                that._lastActive = that._downTarget;
                that._items = null;
            },
            _invalidateSelectables: function (position, ctrlKey) {
                var idx, length, target = this._downTarget[0], items = this._items, related, toSelect;
                for (idx = 0, length = items.length; idx < length; idx++) {
                    toSelect = items.eq(idx);
                    related = toSelect.add(this.relatedTarget(toSelect));
                    if (collision(toSelect, position)) {
                        if (toSelect.hasClass(SELECTED)) {
                            if (ctrlKey && target !== toSelect[0]) {
                                related.removeClass(SELECTED).addClass(UNSELECTING);
                            }
                        } else if (!toSelect.hasClass(ACTIVE) && !toSelect.hasClass(UNSELECTING)) {
                            related.addClass(ACTIVE);
                        }
                    } else {
                        if (toSelect.hasClass(ACTIVE)) {
                            related.removeClass(ACTIVE);
                        } else if (ctrlKey && toSelect.hasClass(UNSELECTING)) {
                            related.removeClass(UNSELECTING).addClass(SELECTED);
                        }
                    }
                }
            },
            value: function (val, e) {
                var that = this, selectElement = proxy(that._selectElement, that);
                if (val) {
                    val.each(function () {
                        selectElement(this);
                    });
                    that._notify(CHANGE, e);
                    return;
                }
                return that.element.find(that.options.filter + '.' + SELECTED);
            },
            _firstSelectee: function () {
                var that = this, selected;
                if (that._lastActive !== null) {
                    return that._lastActive;
                }
                selected = that.value();
                return selected.length > 0 ? selected[0] : that.element.find(that.options.filter)[0];
            },
            _selectElement: function (element, preventNotify) {
                var toSelect = $(element), isPrevented = !preventNotify && this._notify('select', { element: element });
                toSelect.removeClass(ACTIVE);
                if (!isPrevented) {
                    toSelect.addClass(SELECTED);
                    if (this.options.aria) {
                        toSelect.attr(ARIASELECTED, true);
                    }
                }
            },
            _notify: function (name, args) {
                args = args || {};
                return this.trigger(name, args);
            },
            _unselect: function (element) {
                if (this.trigger(UNSELECT, { element: element })) {
                    return;
                }
                element.removeClass(SELECTED);
                if (this.options.aria) {
                    element.attr(ARIASELECTED, false);
                }
                return element;
            },
            _select: function (e) {
                if (this._allowSelection(e.event.target)) {
                    if (!msie || msie && !$(kendo._activeElement()).is(this.options.inputSelectors)) {
                        e.preventDefault();
                    }
                }
            },
            _allowSelection: function (target) {
                if ($(target).is(this.options.inputSelectors)) {
                    this.userEvents.cancel();
                    this._downTarget = null;
                    return false;
                }
                return true;
            },
            resetTouchEvents: function () {
                this.userEvents.cancel();
            },
            clear: function () {
                var items = this.element.find(this.options.filter + '.' + SELECTED);
                this._unselect(items);
            },
            selectRange: function (start, end, e) {
                var that = this, idx, tmp, items;
                that.clear();
                if (that.element.length > 1) {
                    items = that.options.continuousItems();
                }
                if (!items || !items.length) {
                    items = that.element.find(that.options.filter);
                }
                start = $.inArray($(start)[0], items);
                end = $.inArray($(end)[0], items);
                if (start > end) {
                    tmp = start;
                    start = end;
                    end = tmp;
                }
                if (!that.options.useAllItems) {
                    end += that.element.length - 1;
                }
                for (idx = start; idx <= end; idx++) {
                    that._selectElement(items[idx]);
                }
                that._notify(CHANGE, e);
            },
            destroy: function () {
                var that = this;
                Widget.fn.destroy.call(that);
                that.element.off(NS);
                that.userEvents.destroy();
                that._marquee = that._lastActive = that.element = that.userEvents = null;
            }
        });
        Selectable.parseOptions = function (selectable) {
            var asLowerString = typeof selectable === 'string' && selectable.toLowerCase();
            return {
                multiple: asLowerString && asLowerString.indexOf('multiple') > -1,
                cell: asLowerString && asLowerString.indexOf('cell') > -1
            };
        };
        function collision(element, position) {
            if (!element.is(':visible')) {
                return false;
            }
            var elementPosition = kendo.getOffset(element), right = position.left + position.width, bottom = position.top + position.height;
            elementPosition.right = elementPosition.left + kendo._outerWidth(element);
            elementPosition.bottom = elementPosition.top + kendo._outerHeight(element);
            return !(elementPosition.left > right || elementPosition.right < position.left || elementPosition.top > bottom || elementPosition.bottom < position.top);
        }
        kendo.ui.plugin(Selectable);
    }(window.kendo.jQuery));
    return window.kendo;
}, typeof define == 'function' && define.amd ? define : function (a1, a2, a3) {
    (a3 || a2)();
}));